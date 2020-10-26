import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from 'ngx-custom-validators/node_modules/@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BaseComponent } from 'src/app/core/base-components/base.component';
import { Role } from 'src/app/core/models/role';
import { RoleService } from 'src/app/core/services/role.service';
import { QueryStringUtils } from 'src/app/core/utils/query-string-utils';

@Component({
  selector: 'app-role-list',
  templateUrl: './list.component.html'
})
export class ListComponent extends BaseComponent implements OnInit {

  showSearchForm: boolean = false;
  roles: Role[] = [];
  public searchForm: FormGroup;
  private roleSearch: Role;

  private queryString = new QueryStringUtils();

  constructor(private router: Router,
    private roleService: RoleService,
    private fb: FormBuilder,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) {
    super();
  }

  ngOnInit(): void {
    let url: any = this.queryString.parseUrl(this.router.url);

    this.searchForm = this.fb.group({
      name: [url.query.name ?? ''],
      enabled: [url.query.enabled ?? 'true']
    });

    this.search();
  }

  toggleFormSearch() {
    this.showSearchForm = !this.showSearchForm;
  }

  async search() {
    this.spinner.show();

    this.roleSearch = Object.assign({}, this.roleSearch, this.searchForm.value);
    this.roleService.searchRoles(this.roleSearch).subscribe(
      r => {
        this.roles = r;
        this.spinner.hide();
      },
      err => {
        console.log(err);
        this.spinner.hide();
      }
    );
  }

  async deleteRole(id: number) {

    let confirm = await this.showConfirmBox('Atenção', 'Realmente deseja APAGAR esta Funação? Esse procedimento não poderá ser revertido!');

    if (!confirm.isConfirmed) return;

    this.spinner.show();
    this.roleService.disableRole(id).subscribe(
      success => {
        this.search();
        this.toastr.success('Item desativado com sucesso!', 'Sucesso');
      },
      error => {
        this.toastr.error('Ocorreu um erro ao desativar o item!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }
}
