import { Component} from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'src/app/core/utils/localstorage';
import { SidenavStore } from '../sidenav/sidenav.store';

@Component({
  selector: 'app-navbar-dashboard',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent {

  private localStorageUrl: LocalStorageUtils = new LocalStorageUtils();

  constructor(private sidenavStore: SidenavStore, private router: Router) { }

  collapsar() {
    this.sidenavStore.toggle();
  }

  getUsername() : string {
    let user = this.localStorageUrl.obterUsuario();
    return user?.email ?? '';
  }

  logout() {
    this.localStorageUrl.limparDadosLocaisUsuario();
    this.router.navigate(['/login']);
  }

}