import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { HttpService } from 'src/app/services/http.service';

import { Place } from 'src/app/Models/place';
import { Forecast } from 'src/app/Models/forecast';

@Injectable({
  providedIn: 'root'
})
export class ForecastService {

  placeUrl = "places";
  forecastUrl = "forecast"; 
  constructor(private httpService: HttpService) { }

  getPlaces(): Observable<Place[]> {
    const params = new HttpParams();
    return this.httpService.getRequest<Place[]>(this.placeUrl, params);
  }

  getweatherForecast(code: string): Observable<Forecast> {
    const params = new HttpParams()
      .append('place', code);
      return this.httpService.getRequest<Forecast>(this.forecastUrl, params);
  }

}
