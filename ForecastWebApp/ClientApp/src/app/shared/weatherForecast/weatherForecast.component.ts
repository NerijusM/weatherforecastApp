import { Component, Input, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { Forecast } from 'src/app/Models/forecast';
import { ForecastService } from 'src/app/services/forecast.service';

@Component({
  selector: 'app-weatherForecast',
  templateUrl: './weatherForecast.component.html',
  styleUrls: ['./weatherForecast.component.css']
})
export class WeatherForecastComponent implements OnInit, OnChanges {

  @Input() placeCode: string = "";

  public forecast: Forecast = {} as Forecast;;

  constructor(private forecastService: ForecastService) { }

  ngOnInit(): void {
  }

  ngOnChanges(): void {
    this.fetchWeatherForecast();
  }

  fetchWeatherForecast() {
    if(this.placeCode.length == 0) {
      return;
    }
    this.forecastService.getweatherForecast(this.placeCode)
    .subscribe({
      next: (forecast) => { 
        this.forecast = forecast; 
      },
      error: (err) => console.log(err)
    })
  }

}
