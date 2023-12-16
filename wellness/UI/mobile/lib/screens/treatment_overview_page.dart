import 'package:flutter/material.dart';
import 'package:mobile/models/category.dart';
import 'package:mobile/models/treatment.dart';
import 'package:mobile/models/treatment_type.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/treatment_provider.dart';
import 'package:mobile/providers/treatment_type_provider.dart';
import 'package:mobile/screens/treatment_details.dart';
import 'package:mobile/widgets/app_bar.dart';

class TreatmentOverview extends StatefulWidget {
  const TreatmentOverview({Key? key}) : super(key: key);

  @override
  State<TreatmentOverview> createState() => _TreatmentOverviewState();
}

class _TreatmentOverviewState extends State<TreatmentOverview> {
  final TreatmentProvider _treatmentProvider = TreatmentProvider();
  final CategoryProvider _categoryProvider = CategoryProvider();
  final TreatmentTypeProvider _treatmentTypeProvider = TreatmentTypeProvider();

  List<Treatment> filterData = [];
  List<Treatment> myData = [];
  List<Category> categories = [];
  List<TreatmentType> treatmentTypes = [];
  String? selectedTreatment; 
  String? selectedCategory; 

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
    myData = await _treatmentProvider.get();
    categories = await _categoryProvider.get();
    treatmentTypes = await _treatmentTypeProvider.get();

    setState(() {
      filterData = myData;
    });
  }

  @override
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            const SizedBox(height: 20),
            Container(
              width: MediaQuery.of(context).size.width * 0.9,
              padding: const EdgeInsets.all(10),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  _buildDropdown(
                    label: "Enter treatment type",
                    value: selectedTreatment,
                    onChanged: (value) {
                      setState(() {
                        selectedTreatment = value;
                      });
                    },
                    items: treatmentTypes.map((type) => type.name).toList(),
                  ),
                  const SizedBox(height: 20),
                  _buildDropdown(
                    label: "Enter category",
                    value: selectedCategory,
                    onChanged: (value) {
                      setState(() {
                        selectedCategory = value;
                      });
                    },
                    items: categories.map((category) => category.name).toList(),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 20),
            SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: DataTable(
                columns: const [
                  DataColumn(
                    label: Text(
                      "Treatment Type",
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 16,
                      ),
                      textAlign: TextAlign.center,
                    ),
                  ),
                ],
                rows: myData
                    .map(
                      (data) => DataRow(
                        cells: [
                          DataCell(
                            Text(data.description),
                            onTap: () {
                              Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => TreatmentDetails(
                                          data: data,
                                        )),
                              );
                            },
                          ),
                        ],
                      ),
                    )
                    .toList(),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildDropdown({
    required String label,
    required String? value,
    required ValueChanged<String?> onChanged,
    required List<String> items,
  }) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Padding(
          padding: const EdgeInsets.symmetric(vertical: 8.0),
          child: Text(
            label,
            style: const TextStyle(
              fontWeight: FontWeight.bold,
              fontSize: 18,
            ),
            textAlign: TextAlign.center,
          ),
        ),
        Center(
          child: SizedBox(
            width: double.infinity,
            child: DropdownButton<String>(
              value: value,
              onChanged: onChanged,
              itemHeight: 50.0,
              underline: Container(
                width: double.infinity, 
                height: 1,
                color: Colors.grey,
              ),
              isExpanded: true, 
              hint: const Center(
                child: Text("Select", textAlign: TextAlign.center),
              ), 
              items: items
                  .map<DropdownMenuItem<String>>(
                    (String value) => DropdownMenuItem<String>(
                      value: value,
                      child: Center(child: Text(value)),
                    ),
                  )
                  .toList(),
            ),
          ),
        ),
      ],
    );
  }
}
