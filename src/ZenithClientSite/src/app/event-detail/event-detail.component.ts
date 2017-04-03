import { Component, OnInit, Input } from '@angular/core';
import {Event} from '../Event'
import {Activity} from '../Activity'
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';
import { EventService } from '../event.service';
import { ActivityService } from '../activity.service';


@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css'],
  providers: [EventService, ActivityService]
})
export class EventDetailComponent implements OnInit {



  constructor(
  private eventService: EventService,
  private activityService: ActivityService,
  private route: ActivatedRoute,
  private location: Location
  ) { }

  ngOnInit() {
  this.route.params.forEach((params: Params) => {
    let id = +params['id'];
    this.eventService.getEventById(id)
      .then(result => this.selectedEvent = result);
  });
  this.getActivities();
}


  activities: Activity[] = [];

  getActivities(): void {
      this.activityService.getActivities()
    .then(activities => this.activities = activities);
  }

  @Input()
  selectedEvent: Event;
  
  selectedActivity: Activity;


  onChange(val) {
    this.selectedActivity = JSON.parse(val);
    this.selectedEvent.activityDetails.description = this.selectedActivity.description
  }

  goBack(): void {
  this.location.back();
  }

  save(): void {
    this.eventService.update(this.selectedEvent)
      .then(() => this.goBack());
  }

}
