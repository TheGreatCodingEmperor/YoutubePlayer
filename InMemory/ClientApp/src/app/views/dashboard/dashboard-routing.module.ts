import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppMainComponent } from 'src/app/app-main.component';
import { DashboardModule } from './dashboard.module';
import { DashComponent } from './views/dash/dash.component';

const routes: Routes = [
  { path: "dash", component: AppMainComponent, children: [
    { path: "board", component: DashComponent}
  ] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
