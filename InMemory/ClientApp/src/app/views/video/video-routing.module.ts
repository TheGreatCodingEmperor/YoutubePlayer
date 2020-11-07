import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppMainComponent } from 'src/app/app-main.component';
import { PlayerComponent } from './components/player/player.component';
import { VideoComponent } from './components/video/video.component';

const routes: Routes = [
  { path:'video', component:AppMainComponent, children:[
    { path:'test', component:VideoComponent },
    { path:'player', component: PlayerComponent }
  ] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VideoRoutingModule { }
