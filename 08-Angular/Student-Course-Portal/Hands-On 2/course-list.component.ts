import { Component } from '@angular/core';
import { CourseCardComponent } from '../../components/course-card/course-card.component';

@Component({
selector:'app-course-list',
standalone:true,
imports:[CourseCardComponent],
templateUrl:'./course-list.component.html',
styleUrls:['./course-list.component.css']
})
export class CourseListComponent{

selectedCourseId:number=0;

courses=[

{id:1,name:'Angular',code:'ANG101',credits:4},

{id:2,name:'Java',code:'JAVA101',credits:3},

{id:3,name:'SQL',code:'SQL101',credits:2},

{id:4,name:'Spring',code:'SPR101',credits:4},

{id:5,name:'React',code:'RE101',credits:3}

];

onEnroll(id:number){

console.log(id);

this.selectedCourseId=id;

}

}
