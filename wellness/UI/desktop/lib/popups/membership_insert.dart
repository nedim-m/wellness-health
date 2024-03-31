import 'package:desktop/models/membership.dart';
import 'package:desktop/models/membership_type.dart';
import 'package:desktop/models/search_result.dart';
import 'package:desktop/models/user.dart';
import 'package:desktop/providers/membership_provider.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:desktop/utils/current_date.dart';
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
  final MembershipProvider membershipProvider = MembershipProvider();

  MembershipType? selectedMembershipType;
  List<MembershipType> allMembershipType = [];
  SearchResult<MembershipType> myData = SearchResult<MembershipType>();
  SearchResult<Membership> myDataUser = SearchResult<Membership>();
  Membership? userMembership;

  var currentDate = CurrentDate();

  @override
  void initState() {
    fetchData(); // Ovdje inicijalizirajte varijablu userMembership
    super.initState();
  }

  Future<void> fetchData() async {
    myData = await membershipTypeProvider.get();
    myDataUser =
        await membershipProvider.get(filter: {'userId': widget.data.id});
    setState(() {
      allMembershipType = myData.result;
      userMembership =
          myDataUser.result.isNotEmpty ? myDataUser.result.first : null;
    });
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

    final bool showMembershipInfo = widget.data.status;

    return AlertDialog(
      backgroundColor: Colors.white,
      title: Text(
        widget.data.status ? "Produži članarinu" : "Dodaj članarinu",
      ),
      content: Form(
        key: _formKey,
        child: SingleChildScrollView(
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              _buildReadOnlyField(
                  "Ime i prezime", "${firstName.text} ${lastName.text}"),
              _buildReadOnlyField("Korisničko ime", userName.text),
              const Divider(),
              if (showMembershipInfo) ...[
                _buildReadOnlyField(
                    "Trenutno aktivni tip članarine",
                    userMembership != null
                        ? userMembership!.memberShipTypeName!
                        : 'N/A'),
                _buildReadOnlyField(
                    "Datum prve aktivacije",
                    userMembership != null
                        ? userMembership!.startDate!
                        : 'N/A'),
                _buildReadOnlyField(
                    "Datum isteka",
                    userMembership != null
                        ? userMembership!.expirationDate!
                        : 'N/A'),
                const Divider(),
              ],
              DropdownButtonFormField<MembershipType>(
                value: selectedMembershipType,
                onChanged: (newValue) {
                  setState(() {
                    selectedMembershipType = newValue!;
                  });
                },
                items: allMembershipType.map<DropdownMenuItem<MembershipType>>(
                    (MembershipType membershipType) {
                  return DropdownMenuItem<MembershipType>(
                    value: membershipType,
                    child: Text(membershipType.name),
                  );
                }).toList(),
                hint: const Text("Izaberite Tip članarine"),
                validator: _validation.validateDropdown,
              ),
              _buildReadOnlyField(
                "Trajanje",
                selectedMembershipType != null
                    ? "${selectedMembershipType!.duration.toString()} dana"
                    : "N/A",
              ),
              _buildReadOnlyField(
                "Cijena",
                selectedMembershipType != null
                    ? "${selectedMembershipType!.price.toString()} BAM"
                    : "N/A",
              ),
              _buildReadOnlyField("Datum aktivacije", currentDate.currentDate),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            if (_formKey.currentState!.validate()) {
              _formKey.currentState!.save();

              showAddAlert(true);
            }
          },
          child: const Text("Spremi"),
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
            "$label: ",
            style: const TextStyle(fontWeight: FontWeight.bold),
          ),
          Expanded(
            child: Text(value),
          ),
        ],
      ),
    );
  }
}
