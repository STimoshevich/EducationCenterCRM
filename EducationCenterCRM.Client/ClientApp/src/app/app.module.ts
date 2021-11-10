import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './Nav-menu/nav-menu.component';
import { HomeComponent } from './Home/home.component';
import { CommonModule } from '@angular/common';
import { CourseService } from './Services/course.service';
import { IdentityService } from './Services/identity.service';
import { TopicService } from './Services/topic.service';
import { FormsModule } from '@angular/forms';
import { CommonService } from './Services/common.service';
import { TeacherService } from './Services/teacher.service';
import { GroupService } from './Services/group.service';
import { AdministratingGuard } from './Guards/Administrating.guard';

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      {
        path: 'allcourses',
        loadChildren: () =>
          import('./Courses/courses.module').then((m) => m.CoursesModule),
      },
      {
        path: 'indentity',
        loadChildren: () =>
          import('./Identity/Identity.module').then((m) => m.IdentityModule),
      },
      {
        path: 'administrating',
        loadChildren: () =>
          import('./Administrating/Administrating.module').then(
            (m) => m.AdministratingModule
          ),
        canActivate: [AdministratingGuard],
      },
    ]),
  ],
  providers: [
    CourseService,
    GroupService,
    IdentityService,
    TopicService,
    TeacherService,
    CommonService,
    AdministratingGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
