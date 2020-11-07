import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MDBBootstrapModule } from 'angular-bootstrap-md';


@NgModule({
  declarations: [],
  imports: [
    FormsModule,
    MDBBootstrapModule.forRoot()
  ],
  exports: [
    FormsModule,
    MDBBootstrapModule
  ]
})
export class SharedModule { }
