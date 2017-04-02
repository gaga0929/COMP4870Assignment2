import { Component } from '@angular/core';
import { Event } from './Event';
import {Activity} from './Activity';
import {DUMMY_DATA} from './data/dummy-data'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  title ="Zenith Society";

  selected: Event; 

  events = DUMMY_DATA;
  
  onSelect(event: Event): void {
    this.selected= event;
  }

}


