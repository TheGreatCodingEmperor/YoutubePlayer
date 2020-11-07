import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subscribable } from 'rxjs';
import { ConfigService } from 'src/app/services/config.service';

@Injectable({
  providedIn: 'root'
})
export class VideoService extends ConfigService {

  constructor(
    http:HttpClient
  ) { 
    super(http);
  }

  getData(query:string):Subscribable<any>{
    return this.http.get(`${this.baseUrl}/Viedo?query=${query}`);
  }
}
