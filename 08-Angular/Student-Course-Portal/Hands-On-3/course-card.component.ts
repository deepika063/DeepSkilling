isExpanded = false;

toggleDetails() {
  this.isExpanded = !this.isExpanded;
}

get cardClasses() {
  return {
    expanded: this.isExpanded,
    'card--full': this.course.credits >= 4
  };
}

get borderColor() {

  if(this.course.gradeStatus=='passed')
      return '5px solid green';

  if(this.course.gradeStatus=='failed')
      return '5px solid red';

  return '5px solid gray';

}
