import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Place } from 'src/app/Models/place';
import { ForecastService } from 'src/app/services/forecast.service';

@Component({
  selector: 'app-searchPlace',
  templateUrl: './searchPlace.component.html',
  styleUrls: ['./searchPlace.component.css']
})
export class SearchPlaceComponent implements OnInit {

  @Output() selectPlace = new EventEmitter<string>();
  
  public places: Place[] = [];
  public filteredplaces: Place[] = [];
  searchValue: string = "kaunas";
  // public selectedCode: string = "";

  constructor(private forecastService: ForecastService) { }

  ngOnInit(): void {
    this.onSelect(this.searchValue);
    this.forecastService.getPlaces()
    .subscribe({
      next: (places) => { 
        this.places = places; 
      },
      error: (err) => console.log(err)
    })
  };

  keyup(val: string) {
    this.searchValue = val;
    this.filteredplaces = this.filterItems(val);
    console.log(this.searchValue);
  }

  filterItems(query: string): Place[] {
    return this.places.filter((el) => el.name.toLowerCase().includes(query.toLowerCase()));
  }

  onSelect(code: string) {
    this.resetFilter();
    this.selectPlace.emit(code);
  }

  resetFilter() {
    this.filteredplaces = [];
  }
}
