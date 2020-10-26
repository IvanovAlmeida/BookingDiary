import { Component, ElementRef, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements OnInit {
  public mainHeight: number = 0;
  constructor(private elementRef: ElementRef) { }

  ngOnInit(): void {
    this.mainHeight = window.innerHeight - 54;
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#FFFFFF';
  }
}
