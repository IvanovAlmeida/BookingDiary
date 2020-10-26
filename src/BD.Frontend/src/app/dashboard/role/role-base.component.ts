import { FormGroup } from '@angular/forms';
import { ElementRef } from "@angular/core";

import { FormBaseComponent } from '../../core/base-components/form-base.component';
import { Role } from '../../core/models/role';

export abstract class RoleBaseComponent extends FormBaseComponent {
    role: Role;
    errors: any[] = [];
    roleForm: FormGroup;

    constructor() {
        super();

        this.validationMessages = {
            name: {
                required: 'Informe um nome',
                minlength: 'Mínimos de 2 caracretes',
                maxlength: 'Máximo de 100 caracteres'
            },            
            description: {
                minlength: 'Mínimos de 2 caracretes',
                maxlength: 'Máximo de 500 caracteres'
            }
        };

        this.configurarMensagensValidacaoBase(this.validationMessages);
    }

    protected configureFormValidation(formInputElements: ElementRef[]) {
        super.configurarValidacaoFormularioBase(formInputElements, this.roleForm);
    }
}