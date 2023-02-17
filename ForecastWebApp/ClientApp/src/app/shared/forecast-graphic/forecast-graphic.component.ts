import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ForecastTimestamp } from 'src/app/Models/forecastTimestamp';

@Component({
  selector: 'app-forecast-graphic',
  templateUrl: './forecast-graphic.component.html',
  styleUrls: ['./forecast-graphic.component.css']
})
export class ForecastGraphicComponent implements OnInit, OnChanges {

  @Input() forecastTimestamp: ForecastTimestamp[] = [];
  
  public graph : any;

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(): void {
    this.setChartOptions();
  }

  setChartOptions() {

    var airTemperature = { x: this.forecastTimestamp.map(c => new Date(c.forecastLocalTime)), 
      y: this.forecastTimestamp.map(c => c.airTemperature), 
      type: 'scatter', 
      mode: 'lines+points', 
      marker: {color: 'red'}, 
      name: 'Air temperature [C]'
    };

    var feelsLiakeAirTemperature = { x: this.forecastTimestamp.map(c => new Date(c.forecastLocalTime)), 
      y: this.forecastTimestamp.map(c => c.feelsLikeTemperature), 
      type: 'line',
      line: {
        dash: 'dot',
        width: 4
      }, 
      marker: {color: 'pink'}, 
      name: 'Feels like Air temperature [C]'
    };

    var relativeHumidity = { x: this.forecastTimestamp.map(c => new Date(c.forecastLocalTime)), 
      y: this.forecastTimestamp.map(c => c.relativeHumidity), 
      type: 'scatter', 
      mode: 'lines+points',
      marker: {color: 'blue'},
      name: 'Relative Humidity'
    };

    var data = [airTemperature, feelsLiakeAirTemperature];
    var layout = {font: {size: 18}, title: 'Weather forecast'};
    var config = {responsive: true};
    this.graph = { data: data,  layout: layout, config: config};
    
  };
  }

