import { Component, OnInit, Input } from '@angular/core';
import {Event} from '../Event'
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';
import { EventService } from '../event.service';


@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {



  constructor(
  private eventService: EventService,
  private route: ActivatedRoute,
  private location: Location
  ) { }

  ngOnInit() {
  this.route.params.forEach((params: Params) => {
    let id = +params['id'];
    this.eventService.getEventById(id)
      .then(result => this.selectedEvent = result);
  });
}


  @Input()
  selectedEvent: Event;

  goBack(): void {
  this.location.back();
  }

  save(): void {
    this.eventService.update(this.selectedEvent)
      .then(() => this.goBack());
  }

}
