import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VideoRoutingModule } from './video-routing.module';
import { VideoComponent } from './components/video/video.component';
import { SharedModule } from 'src/app/modules/shared.module';
import { PlayerComponent } from './components/player/player.component';
import { SafePipe } from 'src/app/pipes/safe-pipe';


@NgModule({
  declarations: [VideoComponent, PlayerComponent,SafePipe ],
  imports: [
    CommonModule,
    SharedModule,
    VideoRoutingModule
  ]
})
export class VideoModule { }
