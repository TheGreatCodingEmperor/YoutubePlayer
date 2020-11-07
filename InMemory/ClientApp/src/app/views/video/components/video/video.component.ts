import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VideoService } from '../../service/video.service';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.scss']
})
export class VideoComponent implements OnInit {
  videos: object[];
  query: string = '';
  constructor(
    private videoService: VideoService,
    private router:Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.query = this.route.snapshot.queryParamMap.get('query') as string;
    if(this.query){
      this.search();
    }
  }
  search() {
    this.router.navigate(['/video/test'],{queryParams:{query:this.query}});
    this.videoService.getData(this.query).subscribe(res => {
      // this.videos = res;
      this.videos = [];
      res.map(x => {
        try {
          let value = JSON.parse(x);
          console.log(value);
          this.videos.push(value);
        }
        catch {}
      })
      console.log(this.videos);
    }, error => { console.log(error) })
  }
}
