import { Component, OnInit } from '@angular/core';
import {Activity} from '../Activity';
import {ActivityService} from '../activity.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css'],
  providers: [ActivityService]
})
export class ActivityComponent implements OnInit {

  selectedActivity: Activity; 

  
  activities : Activity[];
  

  newActivity: Activity = new Activity();

  add(newActivity: Activity): void {
    
  newActivity.description = newActivity.description.trim();
    
  
  if (!newActivity) { return; }
  this.activityService.create(newActivity)
    .then(newActivity => {
      this.selectedActivity = null;
      this.router.navigate(['./dashboard']);
    });
  }

  
  constructor(private activityService:ActivityService, private router: Router) { } 

  onSelect(activity: Activity): void {
    this.selectedActivity= activity;
  }


  getActivities(): void {
      this.activityService.getActivities()
    .then(activites => this.activities = activites);
  }
  
  ngOnInit(): void {
    this.getActivities();
  }

 gotoDetail(): void {
  this.router.navigate(['/activitydetail', this.selectedActivity.activityId]);
}
 

}
