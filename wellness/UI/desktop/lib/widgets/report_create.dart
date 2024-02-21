import 'package:desktop/models/membership_type.dart';

import 'package:desktop/models/search_result.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:desktop/providers/report_provider.dart';
import 'package:flutter/material.dart';

class CreateReportWidget extends StatefulWidget {
  const CreateReportWidget({Key? key}) : super(key: key);

  @override
  State<CreateReportWidget> createState() => _CreateReportWidgetState();
}

class _CreateReportWidgetState extends State<CreateReportWidget> {
  int? selectedTipClanarine;
  DateTime selectedDateOd = DateTime.now();
  DateTime selectedDateDo = DateTime.now();
  SearchResult<MembershipType> memberShipType = SearchResult<MembershipType>();
  final MembershipTypeProvider _membershipTypeProvider =
      MembershipTypeProvider();

  final ReportProvider _reportProvider = ReportProvider();

  @override
  void initState() {
    fetchData();

    super.initState();
  }

  Future<void> fetchData() async {
    memberShipType = await _membershipTypeProvider.get();
    if (memberShipType.result.isNotEmpty) {
      selectedTipClanarine = memberShipType.result.first.id;
    }
    setState(() {});
  }

  void _showAlertDialog(bool success) {
    String title = success ? "Uspješno" : "Greška";
    String message = success
        ? "Izvještaj je uspješno kreiran. Pogledajte u sekciji Izvještaj/prikaži."
        : "Došlo je do greške prilikom kreiranja izvještaja.";

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text(title),
          content: Text(message),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text('U redu'),
            ),
          ],
        );
      },
    );
  }

  void _saveChanges() async {
    try {
      await _reportProvider.add(
          selectedDateDo, selectedDateOd, selectedTipClanarine!);
      _showAlertDialog(true);
    } catch (e) {
      _showAlertDialog(false);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 16),
            Row(
              children: [
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      DropdownButtonFormField<int>(
                        value: selectedTipClanarine,
                        onChanged: (newValue) {
                          setState(() {
                            selectedTipClanarine = newValue;
                          });
                        },
                        items: memberShipType.result.map((cat) {
                          return DropdownMenuItem<int>(
                            value: cat.id,
                            child: Text(cat.name),
                          );
                        }).toList(),
                        decoration:
                            const InputDecoration(labelText: 'Tip članarine'),
                      ),
                    ],
                  ),
                ),
                const SizedBox(width: 16),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text('Datum od:'),
                      InkWell(
                        onTap: () async {
                          DateTime? pickedDateOd = await showDatePicker(
                            context: context,
                            initialDate: selectedDateOd,
                            firstDate: DateTime(2000),
                            lastDate: DateTime(2101),
                          );
                          if (pickedDateOd != null &&
                              pickedDateOd != selectedDateOd) {
                            setState(() {
                              selectedDateOd = pickedDateOd;
                            });
                          }
                        },
                        child: Row(
                          children: [
                            const Icon(Icons.calendar_today),
                            const SizedBox(width: 8),
                            Text(
                              "${selectedDateOd.toLocal()}".split(' ')[0],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(width: 16),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text('Datum do:'),
                      InkWell(
                        onTap: () async {
                          DateTime? pickedDateDo = await showDatePicker(
                            context: context,
                            initialDate: selectedDateDo,
                            firstDate: DateTime(2000),
                            lastDate: DateTime(2101),
                          );
                          if (pickedDateDo != null &&
                              pickedDateDo != selectedDateDo) {
                            setState(() {
                              selectedDateDo = pickedDateDo;
                            });
                          }
                        },
                        child: Row(
                          children: [
                            const Icon(Icons.calendar_today),
                            const SizedBox(width: 8),
                            Text(
                              "${selectedDateDo.toLocal()}".split(' ')[0],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
            const SizedBox(height: 16),
            Align(
              alignment: Alignment.centerRight,
              child: ElevatedButton(
                onPressed: _saveChanges,
                child: const Text('Kreiraj Izveštaj'),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
