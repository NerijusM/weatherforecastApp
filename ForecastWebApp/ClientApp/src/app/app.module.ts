import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SearchPlaceComponent } from './shared/searchPlace/searchPlace.component';
import { WeatherForecastComponent } from './shared/weatherForecast/weatherForecast.component';
import { WindDirectionComponent } from './shared/wind-direction/wind-direction.component';
import { SafePipe } from './pipes/safe.pipe';

import * as PlotlyJS from 'plotly.js-dist-min';
import { PlotlyModule } from 'angular-plotly.js';
import { ForecastGraphicComponent } from './shared/forecast-graphic/forecast-graphic.component';
import { ForecastPlaceComponent } from './shared/forecast-place/forecast-place.component';

PlotlyModule.plotlyjs = PlotlyJS;

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SearchPlaceComponent,
    WeatherForecastComponent,
    WindDirectionComponent,
    ForecastGraphicComponent,
    ForecastPlaceComponent,
    SafePipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    PlotlyModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: FetchDataComponent, pathMatch: 'full' },
      // { path: 'counter', component: CounterComponent },
      // { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

