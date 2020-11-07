import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashComponent } from './views/dash/dash.component';
import { SharedModule } from 'src/app/modules/shared.module';


@NgModule({
  declarations: [DashComponent],
  imports: [
    CommonModule,
    SharedModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
