import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
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
  load = false;
  constructor(
    private videoService: VideoService,
    private router:Router,
    private route: ActivatedRoute,
    private cdref: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.query = this.route.snapshot.queryParamMap.get('query') as string;
    if(this.query){
      this.search();
    }
  }
  search() {
    this.load = true;
    this.router.navigate(['/video/test'],{queryParams:{query:this.query}});
    this.videoService.getData(this.query).subscribe(res => {
      // this.videos = res;
      this.videos = [];
      res.map(x => {
        try {
          let value = JSON.parse(x);
          value['hover']=false;
          console.log(value);
          this.videos.push(value);
        }
        catch {}
      })
      this.load = false;
      console.log(this.videos);
    }, error => { console.log(error);this.load=false; })
  }

  hover(e:Event,video:object){
    if(!video)return;
    e.preventDefault();
    e.stopPropagation();
    this.cdref.detectChanges();
    console.log("hover");
    console.log(e);
    video['hover']= true;
  }
  leave(e:Event,video:object){
    if(!video)return;
    e.preventDefault();
    e.stopPropagation();
    this.cdref.detectChanges();
    console.log("leave");
    console.log(e);
    video['hover']= false;
  }
}
