import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormControlName, FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';

import { User } from 'src/app/core/models/user';
import { UserService } from 'src/app/core/services/user.service';
import { FormBaseComponent } from 'src/app/core/base-components/form-base.component';
import { CustomValidators } from 'ngx-custom-validators';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-user-add',
  templateUrl: './add.component.html'
})
export class AddComponent extends FormBaseComponent implements OnInit, AfterViewInit {
  
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  addForm: FormGroup;
  user: User;

  constructor(private fb: FormBuilder,
              private router: Router,
              private userService: UserService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService) { 
    super();

    this.validationMessages = {
      name: {
        required: 'Informe o nome',
      },
      email: {
        required: 'Informe o e-mail',
        email: 'Email inválido'
      },
      password: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      confirmPassword: {
        required: 'Informe a senha novamente',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
        equalTo: 'As senhas não conferem'
      }
    };
    super.configurarMensagensValidacaoBase(this.validationMessages);
  }
  
  ngOnInit(): void {
    let password = new FormControl('', [
      Validators.required, CustomValidators.rangeLength([6, 15])
    ]);
    let confirmPassword = new FormControl('', [
      Validators.required, CustomValidators.rangeLength([6, 15]),
      CustomValidators.equalTo(password)
    ]);

    this.addForm = this.fb.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: password,
      confirmPassword: confirmPassword
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.addForm);
  }

  addUser() {
    if(this.addForm.dirty && this.addForm.valid) {
      this.user = Object.assign({}, this.user, this.addForm.value);
      this.spinner.show();
      this.userService.saveUser(this.user)
        .subscribe(
          success => {
            this.proccessSuccess(success);
          },
          error => {
            this.proccessError(error);
          }
        );
    }
  }

  proccessSuccess(response: any) {
    this.addForm.reset();
    this.errors = [];

    this.spinner.hide();
    let toast = this.toastr.success('Usuário cadastrado com Sucesso!', 'Sucesso!', {timeOut: 1500});
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/usuarios']);
      });
    }
  }

  proccessError(fail: any) {
    this.spinner.hide();
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

}
