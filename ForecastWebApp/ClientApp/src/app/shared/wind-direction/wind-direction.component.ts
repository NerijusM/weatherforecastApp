import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-wind-direction',
  templateUrl: './wind-direction.component.html',
  styleUrls: ['./wind-direction.component.css']
})
export class WindDirectionComponent implements OnInit {

  @Input() direction: number = 0;

  rotation: any;
  constructor() { }

  ngOnInit() {
    this.rotation = 'rotate(' + this.direction + 'deg)';
  }
}
