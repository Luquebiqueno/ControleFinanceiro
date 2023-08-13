import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { GastoService } from 'src/app/services/gasto.service';
import { NotifierService } from 'src/app/services/notifier.service';

@Component({
    selector: 'app-dialog',
    templateUrl: './dialog.component.html',
    styleUrls: ['./dialog.component.scss']
})
export class DialogComponent {

    constructor(@Inject(MAT_DIALOG_DATA) public data: any,
                private dialog: MatDialog, 
                private gastoService: GastoService,
                private notifierService: NotifierService) { }

    
    deleteGasto() {
        this.gastoService.deleteGasto(this.data.id.toString()).subscribe((response: any) => {
          this.notifierService.showNotification('Gasto excluído com sucesso','Sucesso', 'success');
          this.dialog.closeAll();
        },
        error => {
          this.notifierService.showNotification('Aconteceu um erro','Erro', 'error');
          this.dialog.closeAll();
        });
    }

}
