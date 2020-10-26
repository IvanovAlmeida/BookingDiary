import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AuthClaim } from 'src/app/core/models/auth';
import { Claim } from 'src/app/core/models/claim';
import { Permission } from 'src/app/core/models/permission';
import { Role } from 'src/app/core/models/role';
import { RoleService } from 'src/app/core/services/role.service';

@Component({
  selector: 'app-permissions',
  templateUrl: './permissions.component.html',
  styleUrls: ['./permissions.component.css']
})
export class PermissionsComponent implements OnInit {

  public role: Role;  
  public permissions: Permission[] = [];

  constructor(
    private route: ActivatedRoute,
    private roleService: RoleService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) {
    this.role = this.route.snapshot.data['role'];
    this.permissions = this.route.snapshot.data['permissions'];

    this.mergeClaimsToPermissions();
  }

  ngOnInit(): void {
    this.spinner.hide();
  }

  private mergeClaimsToPermissions() {
    for(let idx in this.permissions) {
      let perm = this.permissions[idx];
      let claim = this.hasPermission(perm);
      
      perm.claimId = 0;
      perm.hasPermission = false;

      if(claim != null) {
        perm.claimId = claim.id;
        perm.hasPermission = true;
      }
    }
  }

  private hasPermission(permission: Permission) : Claim {

    let claim = this.role.claims.find(claim => claim.claimType === permission.type && claim.claimValue === permission.value);

    if(typeof claim != undefined)
      return claim;
    return null;
  }

  removePermission(permission: Permission) { 
    this.spinner.show();

    let claim = new AuthClaim();
    claim.claimType = permission.type;
    claim.claimValue = permission.value;

    this.roleService.removeClaimToRole(this.role.id, claim).subscribe( 
      success => {
        this.toastr.success('Permissão removida com sucesso!', 'Sucesso');
        
        this.updateList();
      },
      error => {
        this.toastr.error('Ocorreu um erro ao removida a permissão!', 'Ops! :(');
        
        this.updateList();
      }
    );
  }

  addPermission(permission: Permission) { 
    this.spinner.show();

    let claim = new AuthClaim();
    claim.claimType = permission.type;
    claim.claimValue = permission.value;
    claim.id = permission.claimId;
    claim.roleId = this.role.id;

    this.roleService.addClaimToRole(this.role.id, claim).subscribe( 
      success => {
        this.toastr.success('Permissão adicionada com sucesso!', 'Sucesso');
        
        this.updateList();
      },
      error => {
        this.toastr.error('Ocorreu um erro ao adicionada a permissão!', 'Ops! :(');
        
        this.updateList();
      }
    );
  }

  async updateList() {
    this.spinner.show();

    this.roleService.getRole(this.role.id).subscribe(
      r => {
        this.role = r;

        this.mergeClaimsToPermissions();
        this.spinner.hide();
      },
      err => {
        console.log(err);
        this.toastr.error('Ocorreu um erro ao atualizar lista!', 'Ops! :(');
        this.spinner.hide();
      }
    );
  }

  canAddPermission() : boolean {
    let claim = this.hasPermission({ type: 'Role', value: 'AddClaim' } as Permission);
    return claim != undefined;
  }
  canRemovePermission() : boolean {
    let claim = this.hasPermission({ type: 'Role', value: 'RemoveClaim' } as Permission);
    return claim != undefined;
  }
}
