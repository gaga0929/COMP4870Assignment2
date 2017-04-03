import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent }   from './dashboard/dashboard.component';
import { EventComponent } from './event/event.component';
import { EventDetailComponent } from './event-detail/event-detail.component';
import { ActivityComponent } from './activity/activity.component';
import { ActivityDetailComponent } from './activity-detail/activity-detail.component';
const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard',  component: DashboardComponent },
  { path: 'eventdetail/:id', component: EventDetailComponent },
  { path: 'events',     component: EventComponent },
  { path: 'activitydetail/:id', component: ActivityDetailComponent },
  { path: 'activities',   component: ActivityComponent }
];
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}