import { FormGroup } from '@angular/forms';
import { ElementRef } from '@angular/core';

import { FormBaseComponent } from '../../core/base-components/form-base.component';
import { User } from '../../core/models/user';

export abstract class UserBaseComponent extends FormBaseComponent {
    user: User;
    errors: any[] = [];
    userForm: FormGroup;

    constructor() {
        super();

        this.validationMessages = {
            name: {
                required: 'Informe um nome',
                minlength: '',
                maxlenght: ''
            },
            email: {
                required: 'Informe um nome',
                email: ''
            },
            password: {
                required: 'Informe um nome',
                minlength: '',
                maxlenght: ''
            },
            passwordConfirm: {
                required: 'Informe um nome',
                minlength: '',
                maxlenght: ''
            }
        };

        super.configurarMensagensValidacaoBase(this.validationMessages);
    }

    protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
        super.configurarValidacaoFormularioBase(formInputElements, this.userForm);
    }
}