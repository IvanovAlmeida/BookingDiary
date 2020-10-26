import { FormGroup } from '@angular/forms';
import { ElementRef } from "@angular/core";

import { FormBaseComponent } from '../../core/base-components/form-base.component';
import { Item } from '../../core/models/item';

export abstract class ItemBaseComponent extends FormBaseComponent {
    item: Item;
    errors: any[] = [];
    itemForm: FormGroup;

    constructor() {
        super();

        this.validationMessages = {
            name: {
                required: 'Informe um nome',
                minlength: 'Mínimos de 2 caracretes',
                maxlength: 'Máximo de 180 caracteres'
            },
            price: {
                required: 'Informe uma quantidade',
                min: 'Valor mínimo de 1',                
                number: 'Somente números'
            },
            quantity: {
                required: 'Informe uma quantidade',
                min: 'Valor mínimo de 1',
                number: 'Somente números'
            },
            description: {
                minlength: 'Mínimos de 2 caracretes',
                maxlength: 'Máximo de 1000 caracteres'
            }
        };

        super.configurarMensagensValidacaoBase(this.validationMessages);
    }

    protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
        super.configurarValidacaoFormularioBase(formInputElements, this.itemForm);
    }
}