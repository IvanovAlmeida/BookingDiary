import { Component, OnInit } from '@angular/core';

import { SidenavStore } from './sidenav.store';
@Component({
  selector: 'app-sidenav-dashboard',
  templateUrl: './sidenav.component.html'
})
export class SidenavComponent implements OnInit {

  isCollapsed: boolean;

  constructor(private sidenavStore: SidenavStore) { 
    
  }

  ngOnInit(): void {
    this.sidenavStore.isCollapsed().subscribe(_isCollapsed => this.isCollapsed = _isCollapsed);
  }

  closeSidenav(): void {
    if(this.isCollapsed) return;
    this.sidenavStore.close();
  }
}
