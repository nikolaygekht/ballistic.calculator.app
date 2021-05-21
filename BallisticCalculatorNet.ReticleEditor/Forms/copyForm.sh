cp $1Form.cs $2Form.cs
cp $1Form.Designer.cs $2Form.Designer.cs
cp $1Form.resx $2Form.resx

sed -i 's/'$1'Form/'$2'Form/g' $2Form.cs
sed -i 's/'$1'Form/'$2'Form/g' $2Form.Designer.cs

