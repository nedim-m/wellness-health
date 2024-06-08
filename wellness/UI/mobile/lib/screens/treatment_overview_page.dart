import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/category.dart';
import 'package:mobile/models/treatment.dart';
import 'package:mobile/models/treatment_type.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/treatment_provider.dart';
import 'package:mobile/providers/treatment_type_provider.dart';
import 'package:mobile/screens/treatment_details.dart';
import 'package:mobile/utils/app_styles.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/treatment_container.dart';

class TreatmentOverview extends StatefulWidget {
  const TreatmentOverview({Key? key}) : super(key: key);

  @override
  State<TreatmentOverview> createState() => _TreatmentOverviewState();
}

class _TreatmentOverviewState extends State<TreatmentOverview> {
  final TreatmentProvider _treatmentProvider = TreatmentProvider();
  final CategoryProvider _categoryProvider = CategoryProvider();
  final TreatmentTypeProvider _treatmentTypeProvider = TreatmentTypeProvider();

  List<Treatment> filteredData = [];
  List<Treatment> myData = [];
  List<Treatment> treatments = [];
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
    treatments = await _treatmentProvider.recommendation();
    setState(() {
      filteredData = myData;
    });
  }

  void applyFilter() {
    List<Treatment> filteredList = myData;

    if (selectedTreatment != null) {
      filteredList = filteredList
          .where((treatment) => treatment.treatmentType == selectedTreatment)
          .toList();
    }

    if (selectedCategory != null) {
      filteredList = filteredList
          .where((treatment) => treatment.category == selectedCategory)
          .toList();
    }

    setState(() {
      filteredData = filteredList;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Styles.bgColor,
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            const SizedBox(height: 20),
            const Center(
              child: Text(
                'Pregled tretmana',
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.bold,
                  color: Colors.blue,
                ),
              ),
            ),
            const Gap(30),
            Container(
              width: MediaQuery.of(context).size.width * 0.9,
              padding: const EdgeInsets.all(10),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  _buildDropdown(
                    label: "Izaberite tip tretmana",
                    value: selectedTreatment,
                    onChanged: (value) {
                      setState(() {
                        selectedTreatment = value;
                        applyFilter();
                      });
                    },
                    items: treatmentTypes.map((type) => type.name).toList(),
                  ),
                  const SizedBox(height: 20),
                  _buildDropdown(
                    label: "Izaberite kategoriju",
                    value: selectedCategory,
                    onChanged: (value) {
                      setState(() {
                        selectedCategory = value;
                        applyFilter();
                      });
                    },
                    items: categories.map((category) => category.name).toList(),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 20),
            Container(
              width: MediaQuery.of(context).size.width * 0.9,
              padding: const EdgeInsets.all(10),
              child: DataTable(
                headingRowColor: MaterialStateColor.resolveWith(
                    (states) => Colors.blue.shade100),
                dataRowColor:
                    MaterialStateColor.resolveWith((states) => Styles.bgColor),
                columns: const [
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        "Tretmani",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 18,
                          color: Colors.black,
                        ),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ],
                rows: filteredData
                    .map(
                      (data) => DataRow(
                        color: MaterialStateColor.resolveWith(
                          (states) {
                            if (states.contains(MaterialState.hovered)) {
                              return Colors.grey;
                            }
                            return Colors.transparent;
                          },
                        ),
                        cells: [
                          DataCell(
                            InkWell(
                              mouseCursor: SystemMouseCursors.click,
                              onTap: () {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                    builder: (context) => TreatmentDetails(
                                      data: data,
                                    ),
                                  ),
                                );
                              },
                              child: Container(
                                padding: const EdgeInsets.symmetric(
                                    vertical: 10, horizontal: 5),
                                decoration: BoxDecoration(
                                  border: Border(
                                    bottom:
                                        BorderSide(color: Colors.grey.shade300),
                                  ),
                                ),
                                child: Row(
                                  children: [
                                    Expanded(
                                      child: Text(
                                        data.name,
                                        style: const TextStyle(
                                            fontSize: 16,
                                            color: Colors.black87),
                                      ),
                                    ),
                                    const Icon(Icons.arrow_forward),
                                  ],
                                ),
                              ),
                            ),
                          ),
                        ],
                      ),
                    )
                    .toList(),
              ),
            ),
            const SizedBox(height: 30),
            const Center(
              child: Text(
                'Preporučeni tretmani',
                style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: Colors.blue,
                ),
              ),
            ),
            const Gap(20),
            SingleChildScrollView(
              padding: const EdgeInsets.only(left: 20),
              scrollDirection: Axis.horizontal,
              child: Row(
                children: treatments
                    .map((singleTreatment) => GestureDetector(
                          onTap: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                builder: (context) => TreatmentDetails(
                                  data: singleTreatment,
                                ),
                              ),
                            );
                          },
                          child: TreatmentRecomendationView(
                            treatment: singleTreatment,
                          ),
                        ))
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
                child: Text("Izaberite", textAlign: TextAlign.center),
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
