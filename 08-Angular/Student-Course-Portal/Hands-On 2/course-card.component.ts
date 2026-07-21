import {
Component,
Input,
Output,
EventEmitter,
OnChanges,
SimpleChanges
} from '@angular/core';

@Component({
selector:'app-course-card',
standalone:true,
imports:[],
templateUrl:'./course-card.component.html',
styleUrls:['./course-card.component.css']
})
export class CourseCardComponent implements OnChanges{

@Input()

course:any;

@Output()

enrollRequested=new EventEmitter<number>();

ngOnChanges(changes:SimpleChanges){

console.log(changes);

}

enroll(){

this.enrollRequested.emit(this.course.id);

}

}
