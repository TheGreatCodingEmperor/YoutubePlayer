import { AfterViewInit, Component, OnDestroy, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';

@Component({
  selector: 'app-dash',
  templateUrl: './dash.component.html',
  styleUrls: ['./dash.component.scss']
})
export class DashComponent implements OnInit, AfterViewInit, OnDestroy {
  /** @summary stepper */
  @ViewChildren('stepper')stepperElements:QueryList<any>;
  /** @summary stepperNodes */
  steppers = ['1','2','3'];

  /** @summary progressBar */
  progress = 0;
  /** @summary demo progressBar */
  interval;
  /** @summary googleMap */
  public map: any = { lat: 51.678418, lng: 7.809007 };
  
  
  constructor() { }

  ngOnInit(): void {
    this.interval = setInterval(() => {
      if (this.progress < 100)
        this.progress+=10;
      else{
        this.progress = 0;
      }
    }, 1000);
  }
  ngOnDestroy() {
    clearInterval(this.interval);
  }
  ngAfterViewInit(){
    console.log(this.stepperElements.toArray());
    this.stepperElements.toArray().forEach(element => element.nativeElement.style.background = "rgba(50,50,50,0.2)");
  }

  get progressBar(){
    return `width:${this.progress}%`;
  }

  select(e:Event,index:number){
    let el = this.stepperElements.toArray()[index].nativeElement;
    console.log(el.children[0].children[0]);
    // el.style.backgroundColor = "rgba(50,50,50,0.2)";
    el.children[0].children[0].setAttribute('style', 'color:black; background-color:red !important;transition:0.2s;');
  }

}
