import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';
import { AgGridModule } from 'ag-grid-angular';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { ValdemortModule } from 'ngx-valdemort';
import { ConfigurationsRoutingModule } from './configurations-routing.module';
import { ConfigurationsPage } from './configurations.page';
import { ConfigurationsPageLayoutComponent } from '../../ui/configurations-page-layout/configurations-page-layout.component';
import {ConfigurationsFieldsPage} from '../configurations-fields/configurations-fields.page';
import {FieldEditModalComponent} from '../../ui/fields-edit-modal/fields-edit-modal.component';
import {FieldGridComponent} from '../../ui/fields-grid/fields-grid.component';


@NgModule({
  declarations: [
    ConfigurationsPage,
    ConfigurationsPageLayoutComponent,
    ConfigurationsFieldsPage,
    FieldEditModalComponent,
    FieldGridComponent
  ],
  imports: [
    ConfigurationsRoutingModule,
    CommonModule,
    SharedModule,
    AgGridModule,
    NzFormModule,
    ReactiveFormsModule,
    NzModalModule,
    ValdemortModule,
    NzButtonModule,
    NzLayoutModule,
    NzSelectModule,
    NzIconModule,
    NgxMaskDirective,
    NgxMaskPipe,
    NzTableModule,
  ],
  providers: [provideNgxMask()],
})
export class ConfigurationsModule {}
