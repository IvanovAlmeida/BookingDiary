import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from 'src/app/core/services/role.service';
import { RoleBaseComponent } from '../role-base.component';

@Component({
  selector: 'app-role-add',
  templateUrl: './add.component.html'
})
export class AddComponent extends RoleBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor(private fb: FormBuilder, 
              private roleService: RoleService, 
              private spinner: NgxSpinnerService, 
              private toastr: ToastrService,
              private router: Router) { 
    super();
  }

  ngOnInit(): void {
    this.roleForm = this.fb.group({
      name: ['', [
        Validators.required, Validators.minLength(2), Validators.maxLength(100)
      ]],
      description: ['', [
        Validators.minLength(2), Validators.maxLength(500)
      ]]
    });
  }
  ngAfterViewInit(): void {
    super.configureFormValidation(this.formInputElements);
  }

  saveRole() : void {
    if(this.roleForm.dirty && this.roleForm.valid) {
      this.role = Object.assign({}, this.role, this.roleForm.value);

      this.spinner.show();

      this.roleService.addRole(this.role).subscribe(
        success => { this.processSuccess(success); },
        fail => { this.processFail(fail); }
      );
    }
  }

  processSuccess(response: any) {
    this.roleForm.reset();
    this.errors = [];

    this.spinner.hide();

    let toast = this.toastr.success('Grupo de Usuário cadastrado com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/grupos-de-usuario']);
      });
    }
  }

  processFail(fail: any) { 
    this.spinner.hide();
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

}
