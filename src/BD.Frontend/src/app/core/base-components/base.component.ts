import Swal, { SweetAlertIcon } from 'sweetalert2';
import { AuthClaim } from '../models/auth';
import { LocalStorageUtils } from '../utils/localstorage';

export abstract class BaseComponent {

    private localStorageUtils = new LocalStorageUtils();

    protected async showConfirmBox(title: string, text: string, confirmButtonText : string = 'Sim!', icon: SweetAlertIcon = 'warning') {
        return await Swal.fire({
            title: title,
            text: text,
            icon: icon,
            showCancelButton: true,
            cancelButtonColor: 'red',
            cancelButtonText: 'Cancelar',
            showConfirmButton: true,
            confirmButtonColor: 'green',
            confirmButtonText: confirmButtonText,
          });
    }

    protected havePermission(claim: AuthClaim) : boolean {
        if(!this.localStorageUtils.obterTokenUsuario())
            return false;

        let user = this.localStorageUtils.obterUsuario();
        if (!user.claims) return false;

        let userClaim = user.claims.find(x => x.type === claim.type && x.value === claim.value);

        if (!userClaim) return false;

        return true;
    }
}