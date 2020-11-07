
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

import { AppComponent } from './app.component';

import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { FormsModule } from '@angular/forms';
import { TopBarComponent } from './top-bar.component';
import { MenuComponent } from './menu.component';
import { AppMainComponent } from './app-main.component';
import { TestModule } from './views/test/test.module';
import { AppRoutingModule } from './app-routing.module';
import { DashboardModule } from './views/dashboard/dashboard.module';
import { VideoModule } from './views/video/video.module';

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    MenuComponent,
    AppMainComponent
  ],
  imports: [
    BrowserModule,
    TestModule,
    DashboardModule,
    VideoModule,
    BrowserAnimationsModule,
    MDBBootstrapModule.forRoot(),
    AppRoutingModule,
    FormsModule,
  ],
  providers: [{
      provide: LocationStrategy, 
      useClass: HashLocationStrategy
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
