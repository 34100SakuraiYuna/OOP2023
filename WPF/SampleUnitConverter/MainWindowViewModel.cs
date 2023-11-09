using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel{
        private double grammeValue, poundValue;
        #region
        ////プロパティ
        //public double MetricValue {
        //    get { return this.metricValue; }
        //    set {
        //        this.metricValue = value;
        //        this.OnPropertyChanged();
        //    }
        //}


        ////プロパティ
        //public double ImperialValue {
        //    get { return this.imperialValue; }
        //    set {
        //        this.imperialValue = value;
        //        this.OnPropertyChanged();
        //    }
        //}
#endregion
        //プロパティ
        public double GrammeValue {
            get { return this.grammeValue; }
            set {
                this.grammeValue = value;
                this.OnPropertyChanged();
            }
        }


        //プロパティ
        public double PoundValue {
            get { return this.poundValue; }
            set {
                this.poundValue = value;
                this.OnPropertyChanged();
            }
        }



        #region
        ////上のコンボボックスで選択されている値（単位）
        //public MetricUnit CurrentMetricUnit { get; set; }
        ////下のコンボボックスで選択されている値（単位）
        //public ImperialUnit CurrentImperialUnit { get; set; }
        ////▲ボタンで呼ばれるコマンド
        //public ICommand InperialUnitToMetric { get; set; }
        ////▼ボタンで呼ばれるコマンド
        //public ICommand MetricToImperialUnit { get; set; }
        #endregion
        //上のコンボボックスで選択されている値（単位）
        public GrammeUnit CurrentGrammeUnit { get; set; }
        //下のコンボボックスで選択されている値（単位）
        public PoundUnit CurrentPoundUnit { get; set; }
        //▲ボタンで呼ばれるコマンド
        public ICommand PoundUnitToGramme { get; set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand GrammeToPoundUnit { get; set; }



        //コンストラクタ
        public MainWindowViewModel() {
            #region
            //this.CurrentMetricUnit = MetricUnit.Units.First();
            //this.CurrentImperialUnit = ImperialUnit.Units.First();
            //this.MetricToImperialUnit = new DelegateCommand(
            //    () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
            //        this.CurrentMetricUnit, this.MetricValue)
            //    );
            //this.InperialUnitToMetric = new DelegateCommand(
            //    () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(
            //        this.CurrentImperialUnit, this.ImperialValue)
            //    );
            #endregion
            this.CurrentGrammeUnit = GrammeUnit.Units.First();
            this.CurrentPoundUnit = PoundUnit.Units.First();
            this.GrammeToPoundUnit = new DelegateCommand(
                () => this.PoundValue = this.CurrentPoundUnit.FromGrammeUnit(
                    this.CurrentGrammeUnit, this.GrammeValue)
                );
            this.PoundUnitToGramme = new DelegateCommand(
                () => this.GrammeValue = this.CurrentGrammeUnit.FromPoundUnit(
                    this.CurrentPoundUnit, this.PoundValue)
                );

        }
    }
}
