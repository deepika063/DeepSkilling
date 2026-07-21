import {
Directive,
ElementRef,
HostListener,
Input
} from '@angular/core';

@Directive({
selector:'[appHighlight]'
})

export class HighlightDirective{

@Input()

appHighlight='yellow';

constructor(private el:ElementRef){}

@HostListener('mouseenter')

mouseenter(){

this.el.nativeElement.style.backgroundColor=this.appHighlight;

}

@HostListener('mouseleave')

mouseleave(){

this.el.nativeElement.style.backgroundColor='';

}

}
