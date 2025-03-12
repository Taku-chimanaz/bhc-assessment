class QualityMaker {

    private string productType;
    private double productMass; // in kgs

    public QualityMaker(string productType, double productMass){
        this.productType = productType;
        this.productMass = productMass;
    }

    public string ProductType {
        get {
            return productType;
        }

        set {
            productType = value;
        }
    }

    public double ProductMass {
        get {
            return productMass;
        }

        set {
            productMass = value;
        }
    }
}