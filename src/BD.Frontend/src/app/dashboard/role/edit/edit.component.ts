import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Role } from 'src/app/core/models/role';
import { RoleService } from 'src/app/core/services/role.service';
import { RoleBaseComponent } from '../role-base.component';

@Component({
  selector: 'app-role-edit',
  templateUrl: './edit.component.html'
})
export class EditComponent extends RoleBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  public role: Role;

  constructor(private fb: FormBuilder, 
              private route: ActivatedRoute, 
              private router: Router,
              private roleService: RoleService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService) { 

    super();

    this.role = this.route.snapshot.data['role'];
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

    this.roleForm.patchValue({
      id: this.role.id,
      name: this.role.name,
      description: this.role.description
    });

    this.spinner.hide();
  }

  
  ngAfterViewInit(): void {
    super.configureFormValidation(this.formInputElements);
  }

  
  saveRole() {
    if(this.roleForm.dirty && this.roleForm.valid) {
      this.role = Object.assign({}, this.role, this.roleForm.value);
      this.spinner.show();
      this.roleService.updateRole(this.role).subscribe(
        success => { this.proccessSuccess(success); },
        error => { this.proccessError(error); }
      );
    }
  }

  proccessSuccess(response: any) {
    this.roleForm.reset();
    this.errors = [];

    this.spinner.hide();

    let toast = this.toastr.success('Grupo de Usuário editado com sucesso!', 'Sucesso!', { timeOut: 1500 });
    if(toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/dashboard/grupos-de-usuario']);
      });
    }
  }

  proccessError(fail: any) {
    this.spinner.hide();

    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

}
