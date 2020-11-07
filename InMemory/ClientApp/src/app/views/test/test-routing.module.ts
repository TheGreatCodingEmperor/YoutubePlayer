import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppMainComponent } from 'src/app/app-main.component';
import { TestComponent } from './views/test/test.component';

const routes: Routes = [
  { path:"test", component:AppMainComponent, children:[
    { path: "one", component: TestComponent }
  ] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestRoutingModule { }
