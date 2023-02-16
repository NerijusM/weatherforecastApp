import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ForecastService } from '../services/forecast.service';
import { Place } from '../Models/place';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public forecasts: WeatherForecast[] = [];
  public places: Place[] = [];
  public selectedCode: string = "";

  constructor(private forecastService: ForecastService) {
    // console.log(baseUrl);

    // http.get<WeatherForecast[]>(baseUrl + '/weatherforecast/places').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
  }

  ngOnInit(): void {
    // this.forecastService.getPlaces()
    // .subscribe({
    //   next: (places) => this.places = places,
    //   error: (err) => console.log(err)
    // })
  };

  onSelectCode(code: string) {
    this.selectedCode = code;
    console.log(this.selectedCode);
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

