import { Component, OnInit } from '@angular/core';
import { Event } from '../Event';
import {Activity} from '../Activity';
import {EventService} from '../event.service';
import {ActivityService} from '../activity.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css'],
  providers: [ActivityService , EventService]
})

export class EventComponent implements OnInit {

  selectedEvent: Event; 
  
  selectedActivity: Activity;
  
  events : Event[]= [];

  activities: Activity[] = [];

  newEvent: Event = new Event();

  onChange(val) {
    this.selectedActivity = JSON.parse(val);
  }

  add(newEvent: Event): void {
    newEvent.eventId = this.getEvents.length+1
    newEvent.eventStart = newEvent.eventStart.trim();
    newEvent.eventEnd = newEvent.eventEnd.trim();
    newEvent.username = newEvent.username.trim();
    newEvent.creationDate = newEvent.creationDate.trim();
    newEvent.isActive = newEvent.isActive;
    newEvent.activityId = this.getEvents.length
    newEvent.activityDetails = newEvent.activityDetails;
  
  if (!newEvent) { return; }
  this.eventService.create(newEvent)
    .then(newEvent => {
      this.selectedEvent = null;
      this.router.navigate(['./dashboard']);
    });
}

  
  constructor(private eventService:EventService, private activityService:ActivityService, private router: Router) { } 

  onSelect(event: Event): void {
    this.selectedEvent= event;
  }


  getEvents(): void {
      this.eventService.getEvents()
    .then(events => this.events = events);
  }

  getActivities(): void {
      this.activityService.getActivities()
    .then(activities => this.activities = activities);
  }
  
  ngOnInit(): void {
    this.getEvents();
  }

 gotoDetail(): void {
  this.router.navigate(['/eventdetail', this.selectedEvent.eventId]);
}
 

}
