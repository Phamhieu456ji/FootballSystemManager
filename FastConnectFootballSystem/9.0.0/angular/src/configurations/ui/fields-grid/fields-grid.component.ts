import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FieldEditDto,
  FieldListDto,
  FieldServiceProxy
} from '@shared/service-proxies/service-proxies';
import { createGrid, GridOptions } from 'ag-grid-community';
import 'ag-grid-enterprise';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-fields-grid',
  templateUrl: './fields-grid.component.html',
  styles: [],
})
export class FieldGridComponent {

  @Output() onDelete = new EventEmitter<FieldEditDto>();
  @Output() onEdit = new EventEmitter<FieldEditDto>();
  value$!: Observable<FieldListDto[]>;


  gridOptions: GridOptions<FieldListDto> = {
    defaultColDef: {
      editable: true,
      enableRowGroup: true,
      enablePivot: true,
      enableValue: true,
      sortable: true,
      resizable: true,
      filter: false,
    },
    columnDefs: [
      {
        field: 'id',
        headerName: '',
        filter: false,
        sortable: false,
        width: 100,
        headerComponentParams: { template: '<i class="fa fa-cog"></i>' },
        cellRendererParams: {
          onDelete: this.delete.bind(this),
          onEdit: this.edit.bind(this),
        },
      },
      {
        field: 'name',
        headerName: 'Name',
        width: 300,
        flex: 1,
      },
      {
        field: 'status',
        headerName: 'Status',
        width: 300,
      },
    ],
    suppressCellFocus: true,
    paginationPageSize: 10,
    domLayout: 'autoHeight',
    pagination: true,
  };

  constructor(private _fieldService: FieldServiceProxy) {
    this.value$ = _fieldService.getAll('');
  }
  @Input()
  set items(value: FieldListDto[]) {
    //this.gridOptions.api?.setRowData(value);
  }

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
  }

  delete(clinic: FieldEditDto) {
    this.onDelete.emit(clinic);
  }

  edit(clinic: FieldEditDto) {
    this.onEdit.emit(clinic);
  }
}
