import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestRoutingModule } from './test-routing.module';
import { TestComponent } from './views/test/test.component';
import { DataComponent } from './data/data/data.component';
import { SharedModule } from 'src/app/modules/shared.module';


@NgModule({
  declarations: [TestComponent, DataComponent],
  imports: [
    CommonModule,
    SharedModule,
    TestRoutingModule
  ]
})
export class TestModule { }
