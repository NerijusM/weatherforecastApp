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
   
  }

  ngOnInit(): void {
 
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

