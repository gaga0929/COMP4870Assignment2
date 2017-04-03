import { Component, OnInit, Input } from '@angular/core';
import { Activity } from '../Activity'
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';
import { ActivityService } from '../activity.service';

@Component({
  selector: 'app-activity-detail',
  templateUrl: './activity-detail.component.html',
  styleUrls: ['./activity-detail.component.css'],
  providers: [ActivityService]
})
export class ActivityDetailComponent implements OnInit {



  constructor(
  private activityService: ActivityService,
  private route: ActivatedRoute,
  private location: Location
  ) { }

  ngOnInit() {
    this.route.params.forEach((params: Params) => {
    let id = +params['id'];
    this.activityService.getActivityById(id)
      .then(result => this.selectedActivity = result);
  });
}

  @Input()
  selectedActivity: Activity;

 goBack(): void {
  this.location.back();
  }

  save(): void {
    this.activityService.update(this.selectedActivity)
      .then(() => this.goBack());
  }
}
