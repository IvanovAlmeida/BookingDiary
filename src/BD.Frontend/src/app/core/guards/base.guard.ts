import { ActivatedRouteSnapshot, NavigationEnd, Router } from '@angular/router';

import { LocalStorageUtils } from '../utils/localstorage';

export abstract class BaseGuard {

  private localStorageUtils = new LocalStorageUtils();

  constructor(protected router: Router) { }

  protected validateClaims(routeAc: ActivatedRouteSnapshot): boolean {

    if (!this.localStorageUtils.obterTokenUsuario()) {
      this.router.navigate(['/login'], { queryParams: { returnUrl: this.router.url } });
    }

    let user = this.localStorageUtils.obterUsuario();

    let claim: any = routeAc.data[0];

    if (claim !== undefined) {
      let claim = routeAc.data[0]['claim'];

      if (claim) {
        if (!user.claims) 
          this.navigateAccessDenied();

        let claimValues : string[] = claim.value.split('|');
        let userClaim = user.claims.find(x => x.type === claim.type && claimValues.includes(x.value));

        if (!userClaim) 
          this.navigateAccessDenied()
      }
    }

    return true;
  }

  protected validateIsLogged(): boolean {
    if(!this.localStorageUtils.obterTokenUsuario())
      this.router.navigate(['/login'], { queryParams: { returnUrl: this.router.url } });

    return true;
  }

  private navigateAccessDenied() {    
    this.router.navigate(['dashboard/acesso-negado']);
  }
}