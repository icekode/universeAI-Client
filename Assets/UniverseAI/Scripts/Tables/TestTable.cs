using UnityEngine;
using SLS.Widgets.Table;

//TODO Table Implementation does not work with NGUI. Either implement or remove altogether.
public class TestTable: MonoBehaviour {
    private Table table;
    void Start () {
        this.table = this.GetComponent<Table>();
        this.table.ResetTable();
        this.table.AddTextColumn("Column1");
        this.table.AddTextColumn("Column2");
        this.table.AddTextColumn("Column3");
// Initialize Your Table
        this.table.Initialize(this.OnTableSelected);
// Populate Your Rows (obviously this would be real data here)
        for(int i = 0; i < 100; i++) {
            Datum d = Datum.Body(i.ToString());
            d.elements.Add("Col1:Row" + i.ToString());
            d.elements.Add("Col2:Row" + i.ToString());
            d.elements.Add("Col3:Row" + i.ToString());
            this.table.data.Add(d);
        }
// Draw Your Table
        this.table.StartRenderEngine();
    }
    private void OnTableSelected(Datum datum, Column column) {
        string cidx = "N/A";
        if(column != null) cidx = column.idx.ToString();
        if(datum != null)
            print("You Clicked: " + datum.uid + " Column: " + cidx);
    }
}

