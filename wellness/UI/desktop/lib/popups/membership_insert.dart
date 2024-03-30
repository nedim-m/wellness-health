import 'package:desktop/models/membership_type.dart';
import 'package:desktop/models/search_result.dart';
import 'package:desktop/models/user.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:desktop/utils/validation_rules.dart';
import 'package:flutter/material.dart';

class MembershipInsertPopUpWidget extends StatefulWidget {
  const MembershipInsertPopUpWidget(
      {super.key, required this.data, required this.refreshCallback});

  final User data;
  final Function() refreshCallback;

  @override
  State<MembershipInsertPopUpWidget> createState() =>
      _MembershipInsertPopUpWidgetState();
}

class _MembershipInsertPopUpWidgetState
    extends State<MembershipInsertPopUpWidget> {
  final _validation = ValidationRules();
  final _formKey = GlobalKey<FormState>();
  TextEditingController firstName = TextEditingController();
  TextEditingController lastName = TextEditingController();
  TextEditingController userName = TextEditingController();
  TextEditingController email = TextEditingController();
  final MembershipTypeProvider membershipTypeProvider =
      MembershipTypeProvider();

  SearchResult<MembershipType> membershipType = SearchResult<MembershipType>();

  int? selectedMembershipTypeId;

  @override
  void initState() {
    fetchData();
    super.initState();
  }

  Future<void> fetchData() async {
    membershipType = await membershipTypeProvider.get();

    setState(() {});
  }

  void showAddAlert(bool response) {
    String message =
        response ? 'Uspješno dodana članarina' : 'Neuspješna akcija';

    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          backgroundColor: Colors.white,
          title: response ? const Text('Uspješno') : const Text('Neuspješno'),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text('OK'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    firstName.text = widget.data.firstName;
    lastName.text = widget.data.lastName;
    userName.text = widget.data.userName;
    email.text = widget.data.email;

    return AlertDialog(
      backgroundColor: Colors.white,
      title: const Text("Dodaj članarinu"),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            _buildReadOnlyField("Ime", firstName.text),
            _buildReadOnlyField("Prezime", lastName.text),
            _buildReadOnlyField("Email", email.text),
            _buildReadOnlyField("Korisničko ime", userName.text),
            DropdownButtonFormField<int>(
              value: selectedMembershipTypeId,
              onChanged: (newValue) {
                setState(() {
                  selectedMembershipTypeId = newValue;
                });
              },
              items: membershipType.result.map((membershipType) {
                return DropdownMenuItem<int>(
                  value: membershipType.id,
                  child: Text(membershipType.name),
                );
              }).toList(),
              decoration: const InputDecoration(labelText: 'Tip članarine'),
              validator: _validation.validateDropdown,
            ),
          ],
        ),
      ),
      actions: [
        const TextButton(
          onPressed: null, //_saveChanges,
          child: Text("Spremi"),
        ),
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: const Text("Otkaži"),
        ),
      ],
    );
  }

  Widget _buildReadOnlyField(String label, String value) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8.0),
      child: Row(
        children: [
          Text(
            label + ": ",
            style: TextStyle(fontWeight: FontWeight.bold),
          ),
          Expanded(
            child: Text(value),
          ),
        ],
      ),
    );
  }
}
