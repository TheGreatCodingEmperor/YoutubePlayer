import { NgModule } from '@angular/core';
import { RouterModule, Routes, UrlSerializer, DefaultUrlSerializer, UrlTree } from '@angular/router';
import { AppMainComponent } from './app-main.component';
import { Utilities } from './services/utilities.service';

// export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
//   parse(url: string): UrlTree {
//       const possibleSeparators = /[?;#]/;
//       const indexOfSeparator = url.search(possibleSeparators);
//       let processedUrl: string;

//       if (indexOfSeparator > -1) {
//           const separator = url.charAt(indexOfSeparator);
//           const urlParts = Utilities.splitInTwo(url, separator);
//           urlParts.firstPart = urlParts.firstPart.toLowerCase();

//           processedUrl = urlParts.firstPart + separator + urlParts.secondPart;
//       } else {
//           processedUrl = url.toLowerCase();
//       }

//       return super.parse(processedUrl);
//   }
// }

const routes: Routes = [
  { path: '', component: AppMainComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[
    RouterModule
  ],
  providers:[
    {provide: UrlSerializer, useClass:DefaultUrlSerializer}
  ]
})
export class AppRoutingModule { }
